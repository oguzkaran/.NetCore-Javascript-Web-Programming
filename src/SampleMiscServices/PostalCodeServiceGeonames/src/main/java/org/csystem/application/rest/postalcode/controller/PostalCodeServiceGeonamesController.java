package org.csystem.application.rest.postalcode.controller;

import org.csystem.application.rest.postalcode.dto.PostalCodeInfoDTO;
import org.csystem.application.rest.postalcode.dto.PostalCodesDTO;
import org.csystem.application.rest.postalcode.service.PostalCodeAppService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("api/postalcodes")
public class PostalCodeServiceGeonamesController {
    private final PostalCodeAppService m_postalCodeAppService;

    public PostalCodeServiceGeonamesController(PostalCodeAppService postalCodeAppService)
    {
        m_postalCodeAppService = postalCodeAppService;
    }

    @GetMapping("postalcode")
    public PostalCodesDTO findPostalCodeInfoByPostalCode(@RequestParam("code") int postalCode)
    {
        return m_postalCodeAppService.findPostalCodeInfoByPostalCode(postalCode);
    }
}
