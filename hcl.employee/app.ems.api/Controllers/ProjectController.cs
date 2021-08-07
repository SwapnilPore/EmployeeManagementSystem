﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using app.ems.api.Controllers.Interfaces;
using app.ems.api.Models;

namespace app.ems.api.Controllers
{
    public class ProjectController : ApiController, IProject
    {
        private EmployeeManagementSystemEntities db = new EmployeeManagementSystemEntities();

        // GET: api/Project
        public IQueryable<Project> GetProjects()
        {
            return db.Projects;
        }

        // GET: api/Project/5
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> GetProject(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        //// PUT: api/Project/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutProject(int id, Project project)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != project.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(project).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProjectExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Project
        //[ResponseType(typeof(Project))]
        //public async Task<IHttpActionResult> PostProject(Project project)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Projects.Add(project);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        //}

        //// DELETE: api/Project/5
        //[ResponseType(typeof(Project))]
        //public async Task<IHttpActionResult> DeleteProject(int id)
        //{
        //    Project project = await db.Projects.FindAsync(id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Projects.Remove(project);
        //    await db.SaveChangesAsync();

        //    return Ok(project);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}