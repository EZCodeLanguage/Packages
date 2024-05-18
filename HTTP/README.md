# HTTP

Contains the functionality for basic HTTP requests.
- `http` class:
  - `install` method: Install file from url to file.
  - `GET` method: GET request.
  - `POST` method: POST request.
  
```
http install : github.com/EZCodeLanguage/Packages/releases/download/main-package/Main.zip, C:/path/main.zip
undefined result => http GET : ez-code.web.app
http POST : url.com, data, contentType
```

Entire Class:

```
class http {
    method install : @str:url, @str:path {
        runexec http.dll.Http.HTTP.WebInstall ~> {url}, {path}
    }
    method GET : @str:url => @str {
        return runexec http.dll.Http.HTTP.GET ~> {url}
    }
    method POST : @str:url, @str:data, @str:contentType => @str {
        return runexec http.dll.Http.HTTP.GET ~> {url}, {data}, {contentType}
    }
}
```
