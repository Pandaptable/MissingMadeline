#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
cd "$SCRIPT_DIR"

# Configuration (defaults to Release)
CONFIGURATION="${1:-Release}"

# If not running from inside the Celeste Mods dir, download lib-stripped refs
if [ ! -f "../../Celeste.dll" ]; then
    if [ ! -d "lib-stripped" ]; then
        echo "Downloading lib-stripped.zip..."
        curl -fsSL -o lib-stripped.zip \
            "https://github.com/EverestAPI/Everest/releases/latest/download/lib-stripped.zip"
        echo "Extracting..."
        unzip -qo lib-stripped.zip
        rm -f lib-stripped.zip
    fi
    export CelestePrefix="$PWD/lib-stripped"
fi

# Restore NuGet packages
echo "Restoring packages..."
dotnet restore Source/MissingMadeline.csproj

# Build
echo "Building ($CONFIGURATION)..."
dotnet build Source/MissingMadeline.csproj --configuration "$CONFIGURATION" --no-restore

# Package into zip for Release builds
if [ "$CONFIGURATION" = "Release" ]; then
    echo "Packaging MissingMadeline.zip..."
    zip -FSr MissingMadeline.zip \
        everest.yaml \
        bin \
        Ahorn \
        Audio \
        Dialog \
        Graphics \
        Loenn \
        Effects
    echo "Done: MissingMadeline.zip created"
else
    echo "Build complete (Debug - no zip created)"
fi
