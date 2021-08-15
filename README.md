# CarProject

I wanted to show a full stack architecture as I envision it. There are some caveats that need to be addressed

# Backend + DB 
- The db design most likely would be more complex based on all the information that a car can have
    - Conversely KBB has an open API that look promising, in particular the vehicle section of their api http://developer.kbb.com/#!/idws/1-Default
- The backend currently does not implement caching of any sort, this could be a resource hog depending on how many photos a car could have (unlimited as of now). I believe implementing something such as Redis would prevent this
- Normally, I would use a service/repository pattern in the backend. However, I removed it for simplicity
- Backend tests are written in xunit with fluent assertions and nsubstitute

# Frontend
- The frontend can use more tests. Components are fairly simple but can easily be expanded on
- Frontend is super simple. You select a car, hit submit, then get taken to a page with some lists
    - These lists currently do not have sublists but can be easily expanded on since it is built in with MUI
- The request service has the functionality for the other http methods that the backend does not have. This is to show those as generics