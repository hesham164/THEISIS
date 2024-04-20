// server.js
const express = require('express');
const bodyParser = require('body-parser');
const mongoose = require('mongoose');

const app = express();
const port = 3000;

// MongoDB connection
mongoose.connect('mongodb://localhost/ar_curriculum', { useNewUrlParser: true, useUnifiedTopology: true });

// Curriculum schema
const curriculumSchema = new mongoose.Schema({
    title: String,
    description: String,
    file: String // Assuming storing file path
});
const Curriculum = mongoose.model('Curriculum', curriculumSchema);

// Body parser middleware
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

// API endpoint for submitting curriculum data
app.post('/api/curriculum', async (req, res) => {
    try {
        const curriculum = new Curriculum({
            title: req.body.title,
            description: req.body.description,
            file: req.body.file
        });
        await curriculum.save();
        res.status(201).json({ message: 'Curriculum created successfully' });
    } catch (error) {
        console.error(error);
        res.status(500).json({ message: 'Server error' });
    }
});

app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
