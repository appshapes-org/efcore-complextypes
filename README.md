# What is this for?

This repository examines Complex Types in EF Core 8.

# Who is this for?

Developers, platform engineers, and others may use this repository for design and architectural patterns for
implementing Complex Types in EF Core 8.

# What is here?

## Domain

The `Domain` project contains entities for this example repository.

## Tests

The `Tests` project contains unit and service tests for this example repository. Service tests depend on MySQL running.

## Docker Compose

`docker-compose.yml` contains a MySQL definition, as well as a Tests definition.

# What are the dependencies?

- Docker

# How do I run?

```shell
~/projects/efcore-complextypes # make test-all
```