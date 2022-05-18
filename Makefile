##
## Copyright (c) 2021 - Team11. All rights reserved.
##

all: build

build: restore
	dotnet publish -c Release -o ./dist

restore:
	dotnet restore

test:
	cd tests/neo.UnitTests && dotnet test

align-project: src/neo/neo.csproj
	dotnet remove $< reference Neo.VM
	dotnet add $< reference ../neo-vm/src/neo-vm/neo-vm.csproj

clean:
	-@dotnet clean 2>&1 > /dev/null
	-@rm -rf ./dist
	-@rm -rf ./src/neo/bin
	-@rm -rf ./src/neo/obj
	-@rm -rf ./tests/neo.UnitTests/bin
	-@rm -rf ./tests/neo.UnitTests/obj

.PHONY: all build restore test align-project clean

.SILENT: clean
