﻿using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Commands.Create;

public class CreatedCommentResponse : IDto
{
    public int BlogId { get; set; }
    public int ApplicationUserId { get; set; }
    public string CommentMessage { get; set; }
}
