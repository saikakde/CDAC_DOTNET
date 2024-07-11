package com.blogs.service;
//package com.example.railway;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.blogs.entities.Category;
import com.blogs.entities.Railway;
import com.blogs.repository.RailwayRepository;

@Service
public class RailwayService {

    @Autowired
    private RailwayRepository railwayRepository;

    public Railway addRailway(Railway railway) {
        return railwayRepository.save(railway);
    }

    public void deleteRailway(Long id) {
        railwayRepository.deleteById(id);
    }

    public List<Railway> getRailwaysByCategory(Category category) {
        return railwayRepository.findByCategory(category);
    }

    public Optional<Railway> getRailwayById(Long id) {
        return railwayRepository.findById(id);
    }
    
    public List<Railway> getAllRailwaysSortedByName() {
        return railwayRepository.findAllOrderByNameAsc();
    }
}
