using System;
using System.Collections.Generic;
using System.Text;

namespace TestFrameworkAPI.TestBase
{
    public enum StatusCodes
    {
        Created = 201,
        Ok = 200,
        Accepted = 202,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        ServiceUnavailable = 503
    }
     
}
