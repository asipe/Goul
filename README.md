***Work in progress***

##How to run Goul.Console

Goul.Console allows you to setup an app which will upload a given file:

    Goul.Console.exe setcredentials xMyClientIdx xMyClientSecretX
    
Sets the client id and the client secret to a local text file (https://developers.google.com/drive/quickstart-cs).

    Goul.Console.exe getauthurl

Returns a url to a Google process to get an authorization code

    Goul.Console.exe authorize xCodeGivenInThePreviousSetpx

Pass in the code from the previous step and this will grant temporary access based on that code and creates a refresh token which grants long-term access.

    Goul.Console.exe upload xPathOfTheFileToUploadx xNameOfTheFileForGoogleDocsx
    
Uploads a file with those two paramters.




###License

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
