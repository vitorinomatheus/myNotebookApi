namespace Domain.Interfaces.Services;

public interface IGenericCrudService
{
   Task<OutputDto> GetById<InputDto, OutputDto>(InputDto inputDto);

   Task<IEnumerable<OutputDto>> List<InputDto,OutputDto>(InputDto inputDto);

   Task<OutputDto> Insert<InputDto, OutputDto>(InputDto inputDto);
   
   Task<OutputDto> Update<InputDto, OutputDto>(InputDto inputDto);

   Task<OutputDto> Delete<InputDto, OutputDto>(InputDto inputDto);

   Task<IEnumerable<OutputDto>> FilteredList<InputDto, OutputDto>(InputDto inputDto);

 }
