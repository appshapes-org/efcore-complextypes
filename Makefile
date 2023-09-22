build: lint
	dotnet build -warnaserror

clean:
	dotnet clean --verbosity quiet --nologo
	git clean -xdf .ignored
	git clean -xdf Tests/TestResults

commit-only: build test
	git add --verbose :/ .
	git commit -m "$(message)"

commit: commit-only
	git pull
	git push --verbose

down:
	docker compose down

lint:
	dotnet format --verify-no-changes --exclude Tests **/Migrations --verbosity quiet

lint-fix:
	dotnet format --exclude Tests **/Migrations --verbosity quiet

stop:
	docker compose stop $(service)

test:
	dotnet test --environment DOTNET_ENVIRONMENT=Test --no-restore --no-build --verbosity normal --filter "Category!=Service&Category!=Integration" --collect:"XPlat Code Coverage" /p:Exclude=\"[*]*.Migrations.*\" /p:ExcludeByAttribute=\"Obsolete,GeneratedCodeAttribute,CompilerGeneratedAttribute\"

test-coverage: clean build test
	reportgenerator "-reports:**/*Tests*/TestResults/**/coverage.cobertura.xml" "-targetdir:.ignored/coverage-reports" "-classfilters:-*.Migrations.*;-*.*Program*"

test-all:
	docker compose build -q
	docker compose pull -q
	docker compose run --env DOTNET_TEST_CATEGORY=* --rm test

up:
	docker compose build $(service)
	docker compose up -d $(service)
