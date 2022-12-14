using System.Reflection.Metadata;

namespace Domain.Dtos;

public class FoundUserDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Login { get; set; }

    public string Email { get; set; }

    public Blob AvatarPicture { get; set; }
}
