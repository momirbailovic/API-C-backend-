﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EzyFindMobileApi.Model;

namespace EzyFindMobileApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapSettingsRolesController : ControllerBase
    {
        private readonly EzyFind_DevContext _context;

        public MapSettingsRolesController(EzyFind_DevContext context)
        {
            _context = context;
        }

        // GET: api/MapSettingsRoles
        [HttpGet]
        public IEnumerable<MapSettingsRole> GetMapSettingsRole()
        {
            return _context.MapSettingsRole;
        }

        // GET: api/MapSettingsRoles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMapSettingsRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapSettingsRole = await _context.MapSettingsRole.FindAsync(id);

            if (mapSettingsRole == null)
            {
                return NotFound();
            }

            return Ok(mapSettingsRole);
        }

        // PUT: api/MapSettingsRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMapSettingsRole([FromRoute] int id, [FromBody] MapSettingsRole mapSettingsRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mapSettingsRole.Srid)
            {
                return BadRequest();
            }

            _context.Entry(mapSettingsRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapSettingsRoleExists(id))
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

        // POST: api/MapSettingsRoles
        [HttpPost]
        public async Task<IActionResult> PostMapSettingsRole([FromBody] MapSettingsRole mapSettingsRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MapSettingsRole.Add(mapSettingsRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMapSettingsRole", new { id = mapSettingsRole.Srid }, mapSettingsRole);
        }

        // DELETE: api/MapSettingsRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMapSettingsRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapSettingsRole = await _context.MapSettingsRole.FindAsync(id);
            if (mapSettingsRole == null)
            {
                return NotFound();
            }

            _context.MapSettingsRole.Remove(mapSettingsRole);
            await _context.SaveChangesAsync();

            return Ok(mapSettingsRole);
        }

        private bool MapSettingsRoleExists(int id)
        {
            return _context.MapSettingsRole.Any(e => e.Srid == id);
        }
    }
}