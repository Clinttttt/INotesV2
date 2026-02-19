using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Domain.Common
{
    public class Result<T>
    {
        public bool is_success { get; set; }
        public T? value { get; set; }
        public string? error_message { get; set; }
        public int status_code { get; set; }
        public Dictionary<string, string[]>? validation_errors { get; set; }

        public Result(bool is_success, T? value, int status_code = 200, string? error = null)
        {
            this.is_success = is_success;
            this.value = value;
            this.status_code = status_code;
            this.error_message = error;
            validation_errors = null;
        }

        public static Result<T> Success(T value) => new(true, value);
        public static Result<T> Failure(string error_message, int status_code = 400) => new(false, default, status_code, error_message);
        public static Result<T> ValidationFailure(Dictionary<string, string[]> validation_errors)
        {
            return new Result<T>(
                is_success: false,
                value: default,
                status_code: 400,
                error: String.Join("; ", validation_errors.Values))
            {
                validation_errors = validation_errors
            };
        }

        public static Result<T> NotFound() => new(false, default, 404);
        public static Result<T> Unauthorized() => new(false, default, 401);
        public static Result<T> Conflict() => new(false, default, 409);
        public static Result<T> Forbidden() => new(false, default, 403);
        public static Result<T> NoContent() => new(true, default, 204);
        public static Result<T> InternalServerError() => new(false, default, 500);
    }
}
