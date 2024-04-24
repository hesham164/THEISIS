// backend/curriculumModel.js

const mongoose = require('mongoose');

const curriculumSchema = new mongoose.Schema({
    title: String,
    description: String,
    file: String // Assuming storing file path
});

const Curriculum = mongoose.model('Curriculum', curriculumSchema);

module.exports = Curriculum;
