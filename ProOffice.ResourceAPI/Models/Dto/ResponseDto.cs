namespace ProOffice.ResourceAPI.Models.Dto
{
    public class ResponseDto
    {
        public bool IsRequestSuccessful { get; set; } = true;
        public object Result { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
