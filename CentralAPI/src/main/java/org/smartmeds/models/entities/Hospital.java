package org.smartmeds.models.entities;

import io.quarkus.hibernate.orm.panache.PanacheEntity;
import io.quarkus.hibernate.orm.panache.PanacheEntityBase;
import io.smallrye.common.constraint.NotNull;
import jakarta.persistence.*;
import jakarta.validation.*;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.Size;

import java.util.List;

@Entity
public class Hospital extends PanacheEntityBase {
    @Id
    @GeneratedValue
    public Long id;

    @NotNull
    @NotEmpty
    @Size(min = 1, max = 50)
    public String name;

    @NotNull
    @NotEmpty
    @Size(min = 1, max = 100)
    public String city;

    @NotNull
    @NotEmpty
    public String address;

    //FKs

    @OneToMany(mappedBy = "hospital", cascade = CascadeType.ALL, orphanRemoval = true, fetch = FetchType.LAZY)
    List<Listing> listings;
}
