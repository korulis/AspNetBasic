#!/bin/bash
script_name=$0
script_full_path=$(dirname "$0")
(cd $script_full_path && 

echo "Running script as if from $PWD" 

dotnet run --project src/AspNetBasic.WebApi/AspNetBasic.WebApi.csproj

)