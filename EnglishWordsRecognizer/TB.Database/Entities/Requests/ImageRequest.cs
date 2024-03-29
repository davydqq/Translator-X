﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Database.Entities.Requests;

[Table("ImageRequests", Schema = "requests")]
public class ImageRequest : BaseRequest
{

    public ImageRequestTypeENUM ImageRequestTypeId { set; get; }
    public ImageRequestType ImageRequestType { set; get; }

    public ImageRequest() : base(null, 0, 0)
    {

    }

    public ImageRequest(ApiTypeENUM? apiTypeId, double cost, long userId, int userPlanId) : base(apiTypeId, userId, userPlanId)
    {
        InitCost(cost);
    }

    public ImageRequest InitOCR()
    {
        ImageRequestTypeId = ImageRequestTypeENUM.OCR;

        return this;
    }

    public ImageRequest InitImageAnalysis()
    {
        ImageRequestTypeId = ImageRequestTypeENUM.ImageAnalysis;

        return this;
    }
}
