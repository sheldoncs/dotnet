using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace jwtcore.Data.Enums
{
    public enum FacultyCodeEnum
    {
        [EnumMember(Value = "SS")]
        SocialSciences,
        [EnumMember(Value = "LW")]
        Law,
        [EnumMember(Value = "HE")]
        HumanitiesEducation,
        [EnumMember(Value = "PA")]
        ScienceTechnology,
        [EnumMember(Value = "SP")]
        Sport,
        [EnumMember(Value = "MD")]
        MedicalStudies,
        [EnumMember(Value = "GS")]
        GenderStudies,
    }
}
