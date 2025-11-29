package org.smartmeds.models.requests;

import io.smallrye.common.constraint.NotNull;
import jakarta.persistence.Column;
import jakarta.validation.constraints.Positive;
import org.smartmeds.models.entities.Listing;

import java.time.LocalDate;

public class CreateListing {
    @NotNull
    @Positive
    public Double price;

    public LocalDate expirationDate;

    @NotNull
    @Positive
    public Integer quantity;

    @NotNull
    @Column(unique = true)
    public Long medicineFK;

    public Listing toListing() {
        Listing res = new Listing();
        res.setPrice(price);
        res.setExpirationDate(expirationDate);
        res.setMedicineFK(medicineFK);
        res.setQuantity(quantity);

        return res;
    }
}
