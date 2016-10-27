#!/bin/bash
cd /pipeline/source/app
dotnet source.dll --server.urls=http://0.0.0.0:${PORT-"5000"}