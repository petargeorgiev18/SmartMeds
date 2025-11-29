package org.smartmeds.models.requests;

import io.smallrye.common.constraint.NotNull;
import jakarta.persistence.Column;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.Positive;
import org.smartmeds.models.entities.Listing;

import java.time.LocalDate;

public class CreateListing {
    @NotNull
    @Positive
    public Double price;

    public LocalDate expiration;

    @NotNull
    @Column(unique = true)
    public Long medicineFK;

    public Listing toListing() {
        Listing res = new Listing();
        res.setPrice(price);
        res.setExpiration(expiration);
        res.setMedicineFK(medicineFK);

        return res;
    }
}
