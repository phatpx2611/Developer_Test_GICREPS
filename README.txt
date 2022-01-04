-  I used to Clean Architecture with .NET Core 
https://jasontaylor.dev/clean-architecture-getting-started/

- To support CI/CD, I I divided the solution into 3 parts:
   + Infrastructure
   + Application
   + Api 

- With 1 feature I need to
   1. Create table(column) on DB
   2. Create model on Application.Common.Entities.Models
   3. Create data service on infrastructure
   4. Create service by implement data service and follow to the business
   5. Create api follow the route

- If we have a bug(A), I only need to debug and follow 1 flow. 
 	ex: Actual.cs => Actual Data Service => Actual Service => Actual Api
- After fix A, tester can retest this feature until everything be ok => Deploy to main production

=> CI/CD will support the progess automatic and continuous => Reduce risk and save time


