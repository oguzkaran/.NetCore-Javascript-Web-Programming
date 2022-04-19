package org.csystem.application.rest.postalcode.dto;

import java.util.List;

public class PostalCodesDTO {
    private List<PostalCodeInfoDTO> m_postalCodes;

    public List<PostalCodeInfoDTO> getPostalCodes()
    {
        return m_postalCodes;
    }

    public void setPostalCodes(List<PostalCodeInfoDTO> postalCodes)
    {
        m_postalCodes = postalCodes;
    }
}
