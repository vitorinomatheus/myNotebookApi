namespace Domain.Interfaces.Services;

public interface IGenericCrudService
{

   Task<OutputDto> GetById<InputDto, OutputDto>(InputDto inputDto);

   Task<IEnumerable<OutputDto>> List<InputDto,OutputDto>(InputDto inputDto);

   Task<OutputDto> Insert<InputDto, OutputDto>(InputDto inputDto);

 /*
    Receber InputDto vindo da controller, então
    mudar o <T>. Os métodos crud deverão converter
    a dto em entidade, e depois retornar ela em
    dto. Cada um irá realizar a lógica de negócio;
    
 */

}
