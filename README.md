***This is all a work in progress***

##How to run DocumentUploader.Console
  
  Run: scripts\init_minion.ps1
  
  In the command line: 
  
  - minion bootstrap
  - minion clean, build
  
  - To run the unit tests: minion run.unit.tests.dbg
  
  - To run the integration tests:
  
      1)Add a folder named "testconfigs" to the root directory

      2)In that folder add 3 files, "credentials.txt", "file.txt" and "refreshToken.txt"
      
      3)For "credentials.txt": Add the credentials for the Google Account you want to run the IT's in.
      
      4)For "refreshToken.txt": Add the refreshToken for the Google Account you want to run the IT's in (You can use Goul to do this).
  
      5)run.integration.tests.dbg
      
  The executable is run from DocumentUploader.Console and is located in bin\debug\DocumentUploader.Console.exe
  
  Commands:
    - "help"   
    - "setcredentials xClient_IDx xClient_Secretx" 
    - "listcredentials"
    - "clearcredentials"
  


License
---

Goul is licensed under the MIT License

The MIT License (MIT)

    Copyright (c) 2013 Andy Sipe (ajs.general@gmail.com), Morgan Sipe (morgan.talk@gmail.com)

    Permission is hereby granted, free of charge, to any person obtaining a copy of 
    this software and associated documentation files (the "Software"), to deal in the 
    Software without restriction, including without limitation the rights to use, copy, 
    modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
    and to permit persons to whom the Software is furnished to do so, subject to 
    the following conditions:
  
    The above copyright notice and this permission notice shall be included 
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
    OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
