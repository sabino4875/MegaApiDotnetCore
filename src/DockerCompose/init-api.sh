/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P SqlP@ssw0rd!1 -d master -i /tmp/01-database_structure.sql
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P SqlP@ssw0rd!1 -d master -i /tmp/02-table_data.sql