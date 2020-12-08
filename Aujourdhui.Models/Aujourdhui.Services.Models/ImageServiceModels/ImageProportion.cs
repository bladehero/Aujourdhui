using Aujourdhui.Extensions.Attributes;
using System.ComponentModel;

namespace Aujourdhui.Services.Models.ImageServiceModels
{
    public enum ImageProportion
    {
        [Description("")]
        Origin,
        [Description("SQ")]
        [FileNameSeparator("_")]
        Square
    }
}
