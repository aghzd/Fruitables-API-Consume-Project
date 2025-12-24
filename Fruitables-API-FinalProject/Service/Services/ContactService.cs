using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Category;
using Service.DTOs.Contact;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;
        public ContactService(IContactRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(ContactCreateDto model)
        {
            var contact = _mapper.Map<Contact>(model);
            await _repository.CreateAsync(contact);
        }

        public async Task DeleteAsync(int id)
        {
            var deleteContact = await _repository.GetByIdAsync(id);
            if (deleteContact == null) throw new NotFoundException("Contact notfound");
            var contact = _mapper.Map<Contact>(deleteContact);
            await _repository.DeleteAsync(contact);
        }

        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            var contacts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task<ContactDto> GetByIdAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact == null) throw new NotFoundException("Contact notfound");
            return _mapper.Map<ContactDto>(contact);
        }
    }
}