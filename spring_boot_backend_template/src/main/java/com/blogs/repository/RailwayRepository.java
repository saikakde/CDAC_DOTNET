package com.blogs.repository;

import java.util.List;

//package com.example.railway;


import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import com.blogs.entities.Category;
import com.blogs.entities.Railway;

public interface RailwayRepository extends JpaRepository<Railway, Long> {
    List<Railway> findByCategory(Category category);
    
    @Query("SELECT r FROM Railway r ORDER BY r.name ASC")
    List<Railway> findAllOrderByNameAsc();
}
