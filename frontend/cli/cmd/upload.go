/*
Copyright © 2023 NAME HERE <EMAIL ADDRESS>
*/
package cmd

import (
	"bytes"
	"encoding/json"
	"fmt"
	"io"
	"mime/multipart"
	"net/http"
	"os"
	"path/filepath"

	"github.com/spf13/cobra"
)

// uploadCmd represents the upload command
var uploadCmd = &cobra.Command{
	Use:   "upload",
	Short: "Uploads a file to S3 bucket",
	Run: func(cmd *cobra.Command, args []string) {
		upload()
	},
}

func init() {
	rootCmd.AddCommand(uploadCmd)
}

type UploadResponse struct {
	Message     string `json:"message"`
	WavID       string `json:"wav_id"`
	Mp3ID       string `json:"mp3_id"`
	FlacID      string `json:"flac_id"`
	WavPresign  string `json:"wav_presign"`
	Mp3Presign  string `json:"mp3_presign"`
	FlacPresign string `json:"flac_presign"`
}

func upload() {
	//FIX: This needs to be an .env
	baseURL := "https://wasabi-uploader.fly.dev/upload_wav"
	files, _ := filepath.Glob("*")

	for _, file := range files {
		info, _ := os.Stat(file)

		if info.Mode().IsRegular() {
			res, err := uploadFile(baseURL, file)
			if err != nil {
				fmt.Println("Error:", err)
			}
			commit(res)
		}
	}
}

func commit(response UploadResponse) {
	println(response.Mp3Presign)
}

func uploadFile(baseURL, filePath string) (UploadResponse, error) {
	file, err := os.Open(filePath)
	if err != nil {
		return UploadResponse{}, err
	}
	defer file.Close()

	body := &bytes.Buffer{}
	writer := multipart.NewWriter(body)

	part, err := writer.CreateFormFile("file", filepath.Base(filePath))
	if err != nil {
		return UploadResponse{}, err
	}

	_, err = io.Copy(part, file)
	if err != nil {
		return UploadResponse{}, err
	}

	writer.Close()

	req, err := http.NewRequest("POST", baseURL, body)
	if err != nil {
		return UploadResponse{}, err
	}
	req.Header.Set("Content-Type", writer.FormDataContentType())

	client := &http.Client{}
	resp, err := client.Do(req)
	if err != nil {
		return UploadResponse{}, err
	}
	defer resp.Body.Close()

	var uploadResponse UploadResponse
	if err := json.NewDecoder(resp.Body).Decode(&uploadResponse); err != nil {
		return UploadResponse{}, err
	}

	return uploadResponse, nil
}

func main() {
	upload()
}
