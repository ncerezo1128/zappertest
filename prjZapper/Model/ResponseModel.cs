using System;
namespace prjZapper.Model
{
	public class ResponseModel<T>
    {
        public T result { get; set; }
        public int code { get; set; }
        public string? settingsDescription { get; set; }
    }
}

