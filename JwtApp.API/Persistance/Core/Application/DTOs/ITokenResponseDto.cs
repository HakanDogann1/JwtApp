namespace JwtApp.API.Persistance.Core.Application.DTOs
{
	public interface ITokenResponseDto
	{
		DateTime ExpireDate { get; set; }
		string Token { get; set; }
	}
}