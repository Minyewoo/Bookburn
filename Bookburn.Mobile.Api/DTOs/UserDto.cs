namespace Bookburn.Mobile.Api.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public RoleDto[] Roles { get; set; }
    }
}