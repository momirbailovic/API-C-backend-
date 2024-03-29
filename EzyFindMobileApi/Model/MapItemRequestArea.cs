﻿using System;
using System.Collections.Generic;

namespace EzyFindMobileApi.Model
{
    public partial class MapItemRequestArea
    {
        public int IrAreaId { get; set; }
        public int? ItemRequestId { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? SuburbId { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
