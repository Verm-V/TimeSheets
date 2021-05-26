*[Назад](./task-04.md)*  

```sql
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Clients" (
    "Id" uuid NOT NULL,
    "User" uuid NOT NULL,
    CONSTRAINT "PK_Clients" PRIMARY KEY ("Id")
);

CREATE TABLE "Contracts" (
    "Id" uuid NOT NULL,
    "Title" text NULL,
    "DateStart" timestamp without time zone NOT NULL,
    "DateEnd" timestamp without time zone NOT NULL,
    "Description" text NULL,
    CONSTRAINT "PK_Contracts" PRIMARY KEY ("Id")
);

CREATE TABLE "Employees" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_Employees" PRIMARY KEY ("Id")
);

CREATE TABLE "Services" (
    "Id" uuid NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Services" PRIMARY KEY ("Id")
);

CREATE TABLE "Users" (
    "Id" uuid NOT NULL,
    "Username" text NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);

CREATE TABLE "Invoice" (
    "Id" uuid NOT NULL,
    "ContractId" uuid NOT NULL,
    "DateStart" timestamp without time zone NOT NULL,
    "DateEnd" timestamp without time zone NOT NULL,
    "Sum" numeric NOT NULL,
    CONSTRAINT "PK_Invoice" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Invoice_Contracts_ContractId" FOREIGN KEY ("ContractId") REFERENCES "Contracts" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Sheets" (
    "Id" uuid NOT NULL,
    "Date" timestamp without time zone NOT NULL,
    "EmployeeId" uuid NOT NULL,
    "ContractId" uuid NOT NULL,
    "ServiceId" uuid NOT NULL,
    "Amount" integer NOT NULL,
    "InvoiceId" uuid NULL,
    CONSTRAINT "PK_Sheets" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Sheets_Contracts_ContractId" FOREIGN KEY ("ContractId") REFERENCES "Contracts" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Sheets_Employees_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES "Employees" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Sheets_Invoice_InvoiceId" FOREIGN KEY ("InvoiceId") REFERENCES "Invoice" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "FK_Sheets_Services_ServiceId" FOREIGN KEY ("ServiceId") REFERENCES "Services" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Invoice_ContractId" ON "Invoice" ("ContractId");

CREATE INDEX "IX_Sheets_ContractId" ON "Sheets" ("ContractId");

CREATE INDEX "IX_Sheets_EmployeeId" ON "Sheets" ("EmployeeId");

CREATE INDEX "IX_Sheets_InvoiceId" ON "Sheets" ("InvoiceId");

CREATE INDEX "IX_Sheets_ServiceId" ON "Sheets" ("ServiceId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210523163634_InitialCreate', '5.0.6');

COMMIT;

START TRANSACTION;

ALTER TABLE "Invoice" DROP CONSTRAINT "FK_Invoice_Contracts_ContractId";

ALTER TABLE "Sheets" DROP CONSTRAINT "FK_Sheets_Contracts_ContractId";

ALTER TABLE "Sheets" DROP CONSTRAINT "FK_Sheets_Employees_EmployeeId";

ALTER TABLE "Sheets" DROP CONSTRAINT "FK_Sheets_Invoice_InvoiceId";

ALTER TABLE "Sheets" DROP CONSTRAINT "FK_Sheets_Services_ServiceId";

ALTER TABLE "Users" DROP CONSTRAINT "PK_Users";

ALTER TABLE "Sheets" DROP CONSTRAINT "PK_Sheets";

ALTER TABLE "Services" DROP CONSTRAINT "PK_Services";

ALTER TABLE "Employees" DROP CONSTRAINT "PK_Employees";

ALTER TABLE "Contracts" DROP CONSTRAINT "PK_Contracts";

ALTER TABLE "Clients" DROP CONSTRAINT "PK_Clients";

ALTER TABLE "Invoice" DROP CONSTRAINT "PK_Invoice";

ALTER TABLE "Users" RENAME TO users;

ALTER TABLE "Sheets" RENAME TO sheets;

ALTER TABLE "Services" RENAME TO services;

ALTER TABLE "Employees" RENAME TO employees;

ALTER TABLE "Contracts" RENAME TO contracts;

ALTER TABLE "Clients" RENAME TO clients;

ALTER TABLE "Invoice" RENAME TO invoices;

ALTER INDEX "IX_Sheets_ServiceId" RENAME TO "IX_sheets_ServiceId";

ALTER INDEX "IX_Sheets_InvoiceId" RENAME TO "IX_sheets_InvoiceId";

ALTER INDEX "IX_Sheets_EmployeeId" RENAME TO "IX_sheets_EmployeeId";

ALTER INDEX "IX_Sheets_ContractId" RENAME TO "IX_sheets_ContractId";

ALTER TABLE clients RENAME COLUMN "User" TO "UserId";

ALTER INDEX "IX_Invoice_ContractId" RENAME TO "IX_invoices_ContractId";

ALTER TABLE employees ADD "IsDeleted" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE contracts ADD "IsDeleted" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE clients ADD "IsDeleted" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE users ADD CONSTRAINT "PK_users" PRIMARY KEY ("Id");

ALTER TABLE sheets ADD CONSTRAINT "PK_sheets" PRIMARY KEY ("Id");

ALTER TABLE services ADD CONSTRAINT "PK_services" PRIMARY KEY ("Id");

ALTER TABLE employees ADD CONSTRAINT "PK_employees" PRIMARY KEY ("Id");

ALTER TABLE contracts ADD CONSTRAINT "PK_contracts" PRIMARY KEY ("Id");

ALTER TABLE clients ADD CONSTRAINT "PK_clients" PRIMARY KEY ("Id");

ALTER TABLE invoices ADD CONSTRAINT "PK_invoices" PRIMARY KEY ("Id");

ALTER TABLE invoices ADD CONSTRAINT "FK_invoices_contracts_ContractId" FOREIGN KEY ("ContractId") REFERENCES contracts ("Id") ON DELETE CASCADE;

ALTER TABLE sheets ADD CONSTRAINT "FK_sheets_contracts_ContractId" FOREIGN KEY ("ContractId") REFERENCES contracts ("Id") ON DELETE CASCADE;

ALTER TABLE sheets ADD CONSTRAINT "FK_sheets_employees_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES employees ("Id") ON DELETE CASCADE;

ALTER TABLE sheets ADD CONSTRAINT "FK_sheets_invoices_InvoiceId" FOREIGN KEY ("InvoiceId") REFERENCES invoices ("Id") ON DELETE RESTRICT;

ALTER TABLE sheets ADD CONSTRAINT "FK_sheets_services_ServiceId" FOREIGN KEY ("ServiceId") REFERENCES services ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210524092243_SeconfMigration', '5.0.6');

COMMIT;

START TRANSACTION;

ALTER TABLE users ADD "IsDeleted" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE sheets ADD "IsDeleted" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE services ADD "IsDeleted" boolean NOT NULL DEFAULT FALSE;

ALTER TABLE invoices ADD "IsDeleted" boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210524122302_ThirdMigration', '5.0.6');

COMMIT;

START TRANSACTION;

CREATE UNIQUE INDEX "IX_employees_UserId" ON employees ("UserId");

CREATE UNIQUE INDEX "IX_clients_UserId" ON clients ("UserId");

ALTER TABLE clients ADD CONSTRAINT "FK_clients_users_UserId" FOREIGN KEY ("UserId") REFERENCES users ("Id") ON DELETE CASCADE;

ALTER TABLE employees ADD CONSTRAINT "FK_employees_users_UserId" FOREIGN KEY ("UserId") REFERENCES users ("Id") ON DELETE CASCADE;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210525090846_FourthMigration', '5.0.6');

COMMIT;

```