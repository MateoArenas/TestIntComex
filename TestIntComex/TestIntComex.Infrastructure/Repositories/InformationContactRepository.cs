using Microsoft.EntityFrameworkCore;
using TestIntComex.Core.DTOs;
using TestIntComex.Core.Entities;
using TestIntComex.Core.Interfaces;
using TestIntComex.Infrastructure.Data;

namespace TestIntComex.Infrastructure.Repositories
{
    public class InformationContactRepository: IInformationContactRepository
    {
        private readonly IntComexContext _context;

        public InformationContactRepository(IntComexContext context)
        {
            _context = context;
        }

        public async Task<List<ListContactsDto>> ListContacts() 
        {
            List<ListContactsDto> listContacts = new List<ListContactsDto>();

            try
            {
                listContacts = await (from C in _context.TbContact
                                      join CT in _context.TbContactType on C.IdContactType equals CT.Id
                                      select new ListContactsDto
                                      {
                                          strClientCode = C.strClientCode,
                                          strUserName = C.strUserName,
                                          strName = C.strName,
                                          strPosition = C.strPosition,
                                          strPhone = C.strPhone,
                                          strEmail = C.strEmail,
                                          strCellphone = C.strCellphone,
                                          ContactTypeName = CT.Description,
                                          boolAutorizeWebStore = C.boolAutorizeWebStore,
                                          boolAutorizeOrders = C.boolAutorizeOrders,
                                          boolSendInformation = C.boolSendInformation,
                                          strPassword = C.strPassword
                                      }).ToListAsync();

                return listContacts;
            }
            catch
            {
                return listContacts;
            }
        }
        public async Task<List<TbContactType>> ListContactsType()
        {
            try
            {
                return await _context.TbContactType.ToListAsync();
            }
            catch
            {
                return new List<TbContactType>();
            }
        }
        public async Task<ResultsDto> SaveInformation(TbContact contact) 
        {
            ResultsDto resultsDto = new ResultsDto();
            try
            {
                resultsDto = CreatePassword();
                if (!resultsDto.IsSuccess)
                {
                    resultsDto.IsSuccess = false;
                    resultsDto.Description = resultsDto.Description;

                    return resultsDto;
                }
                contact.strPhone = $"+57{contact.strPhone}";
                contact.strPassword = resultsDto.Description;

                await _context.TbContact.AddAsync(contact);
                int result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    resultsDto.IsSuccess = true;
                    resultsDto.Description = "Contacto guardado correctamente.";

                    return resultsDto;
                }
                else
                {
                    resultsDto.IsSuccess = false;
                    resultsDto.Description = "Contacto no guardado. Intentelo más tarde.";

                    return resultsDto;
                }
            }
            catch (Exception ex)
            {
                resultsDto.IsSuccess = false;
                resultsDto.Description = $"Error en el proceso de guardado: {ex.Message}";

                return resultsDto;
            }
        }
        public async Task<bool> IsFullContactType() 
        {
            var list = await _context.TbContactType.ToListAsync();

            if (list.Count() == 0)
                return false;
            else
                return true;
        }
        public async Task<ResultsDto> FillContactType()
        {
            ResultsDto resultsDto = new ResultsDto();
            try
            {
                List<TbContactType> tbContactsType = new List<TbContactType>();
                tbContactsType.Add(new TbContactType
                {
                    Id = 0,
                    Description= "Contacto Comercial"
                });
                tbContactsType.Add(new TbContactType
                {
                    Id = 0,
                    Description = "Pago de factura"
                });
                tbContactsType.Add(new TbContactType
                {
                    Id = 0,
                    Description = "Representante legal"
                });
                tbContactsType.Add(new TbContactType
                {
                    Id = 0,
                    Description = "Retiro de mercadería"
                });

                await _context.TbContactType.AddRangeAsync(tbContactsType);
                int result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    resultsDto.IsSuccess = true;
                    resultsDto.Description = "Tipos de contacto Insertados";

                    return resultsDto;
                }
                else
                {
                    resultsDto.IsSuccess = false;
                    resultsDto.Description = "Tipos de contactos no insertados. Intentelo más tarde.";

                    return resultsDto;
                }
            }
            catch (Exception ex)
            {
                resultsDto.IsSuccess = false;
                resultsDto.Description = $"Error en el proceso de guardado: {ex.Message}";

                return resultsDto;
            }
        }

        #region Private Methods
        private ResultsDto CreatePassword()
        {
            ResultsDto resultsDto = new ResultsDto();
            try
            {

                Random random = new Random();
                string password = $"{random.Next(0, 10)}{random.Next(0, 10)}{random.Next(0, 10)}{random.Next(0, 10)}";
                password = $"{password}{(char)(((int)'A') + random.Next(0, 26))}{(char)(((int)'A') + random.Next(0, 26))}{(char)(((int)'A') + random.Next(0, 26))}{(char)(((int)'A') + random.Next(0, 26))}";


                if (password.Length != 8)
                {
                    resultsDto.IsSuccess = false;
                    resultsDto.Description = "PassWord no valido";
                }

                resultsDto.IsSuccess = true;
                resultsDto.Description = password;

                return resultsDto;
            }
            catch
            {
                resultsDto.IsSuccess = false;
                resultsDto.Description = $"Error al generar la contraseña con sus especificaciones";

                return resultsDto;
            }
        } 
        #endregion
    }
}
