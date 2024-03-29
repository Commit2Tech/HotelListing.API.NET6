﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Core.Models.Country;
using AutoMapper;
using HotelListing.API.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using HotelListing.API.Core.Exceptions;
using HotelListing.API.Core.Models;

namespace HotelListing.API.Controllers
{
    [Route("api/v{version:apiversion}/countries")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
        {
            _mapper = mapper;
            _countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountry()
        {
            // Added below line for improved readability. 
            var countries = await _countriesRepository.GetAllAsync<GetCountryDto>();

            //var records = _mapper.Map<List<GetCountryDto>>(countries);

            return Ok(countries);
        }


        // GET: api/Countries
        [HttpGet("AllCountries")]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountry([FromQuery] QueryParams queryParams)
        {
            // Added below line for improved readability. 
            var pagedRecords = await _countriesRepository.GetAllAsync<GetCountryDto>(queryParams);

            //var records = _mapper.Map<List<GetCountryDto>>(countries);

            return Ok(pagedRecords);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);

            //if (country == null)
            //{
            //    throw new NotFoundException(nameof(GetCountry), id);
            //}

            //var countryDto = _mapper.Map<CountryDto>(country);

            return Ok(country);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(country).State = EntityState.Modified;

            //var country = await _countriesRepository.GetAsync(id);

            //if (country == null)
            //{
            //    return NotFound();
            //}

            //_mapper.Map(updateCountryDto, country);

            try
            {
                await _countriesRepository.UpdateAsync(id, updateCountryDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CountryDto>> PostCountry(CreateCountryDto createCountry)
        {
            var country = _countriesRepository.AddAsync<CreateCountryDto, GetCountryDto>(createCountry);
            
            //var country = _mapper.Map<Country>(createCountry);

            //var country = new Country()
            //{
            //    Name = createCountry.Name,
            //    ShortName = createCountry.ShortName,
            //};
            //_context.Countries.Add(country);
            //await _context.SaveChangesAsync();

            //await _countriesRepository.AddAsync(country);

            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            //var country = await _countriesRepository.GetAsync(id);
            //if (country == null)
            //{
            //    return NotFound();
            //}
            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            //return _context.Countries.Any(e => e.Id == id);
            return await _countriesRepository.Exits(id);
        }
    }
}
