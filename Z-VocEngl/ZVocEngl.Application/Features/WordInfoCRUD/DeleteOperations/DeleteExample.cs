﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ZVocEngl.DAL.Data;

namespace ZVocEngl.Application.Features.WordInfoCRUD.DeleteOperations
{
   public partial class DeleteExample
   {
      public class Command : IRequest<bool>
      {
         public int Id { get; set; }

         public Command(int id)
         {
            Id = id;
         }
      }

      public class Handler : IRequestHandler<DeleteExample.Command, bool>
      {
         private readonly AppDbContext _context;

         public Handler(AppDbContext context)
         {
            _context = context;
         }

         public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
         {
            try
            {
               var item = await _context.Examples.FindAsync(request.Id);
               _context.Examples.Remove(item);
               await _context.SaveChangesAsync();
               return true;
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
               return false;
            }
         }
      }
   }
}