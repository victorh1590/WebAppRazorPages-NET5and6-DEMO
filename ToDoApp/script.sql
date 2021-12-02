CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Todos" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Todos" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL,
    "Date" TEXT NOT NULL,
    "Done" INTEGER NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211202034831_InitialCreation', '6.0.0');

COMMIT;

