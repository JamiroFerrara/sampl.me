publish:
	fly deploy backend/api-s3
	fly deploy backend/api
	fly deploy frontend/web

init:
	git submodule update --init --recursive

debug:
	tmux split-window -h "cargo run --manifest-path backend/api-s3/Cargo.toml"
	tmux split-window -h "dotnet run --project backend/api/api.csproj"
	tmux split-window -h "npm --prefix "frontend/web" run dev"
	tmux select-layout even-vertical
