sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "CREATE DATABASE LibraryApp"
sqlcmd -S "(localdb)\MSSQLLocalDB" -d LibraryApp -i ddl.sql -o ddl.rpt
sqlcmd -S "(localdb)\MSSQLLocalDB" -d LibraryApp -i storedProcedures.sql -o storedProcedures.rpt
sqlcmd -S "(localdb)\MSSQLLocalDB" -d LibraryApp -i data.sql -o data.rpt