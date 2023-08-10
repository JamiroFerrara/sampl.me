publish:
	fly deploy backend/api-s3
	fly deploy backend/api
	fly deploy frontend/web
