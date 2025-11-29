package org.smartmeds.models.entities;

import io.quarkus.hibernate.orm.panache.PanacheEntityBase;
import io.smallrye.common.constraint.NotNull;
import jakarta.persistence.*;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.Positive;

import java.time.LocalDate;

@Entity
public class Listing extends PanacheEntityBase {
    @Id
    @GeneratedValue
    public Long id;

    @NotNull
    @Positive
    Double price;

    @NotNull
    @Positive
    @Min(1)
    Integer quantity;

    @NotNull
    LocalDate expirationDate;

    @NotNull
    @Column(unique = true)
    Long MedicineFK;

    @ManyToOne
    Hospital hospital;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public @Positive Double getPrice() {
        return price;
    }

    public void setPrice(@Positive Double price) {
        this.price = price;
    }

    public LocalDate getExpirationDate() {
        return expirationDate;
    }

    public void setExpirationDate(LocalDate expiration) {
        this.expirationDate = expiration;
    }

    public Long getMedicineFK() {
        return MedicineFK;
    }

    public void setMedicineFK(Long medicineFK) {
        MedicineFK = medicineFK;
    }

    public Hospital getHospital() {
        return hospital;
    }

    public void setHospital(Hospital hospital) {
        this.hospital = hospital;
    }

    public @Positive @Min(1) Integer getQuantity() {
        return quantity;
    }

    public void setQuantity(@Positive @Min(1) Integer quantity) {
        this.quantity = quantity;
    }
}
