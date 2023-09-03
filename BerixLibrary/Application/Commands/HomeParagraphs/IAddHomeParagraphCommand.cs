using Application.DTOs.HomeParagraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.HomeParagraphs
{
  public interface IAddHomeParagraphCommand: ICommand<HomeParagraphDTO>
  {
  }
}
