#!/bin/bash
cd /pipeline/output/app
dotnet source.dll --server.urls=http://0.0.0.0:${PORT-"8080"}