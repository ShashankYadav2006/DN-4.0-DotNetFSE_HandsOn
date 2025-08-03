import React, { useState } from 'react';
import BookDetails from './components/BookDetails';
import BlogDetails from './components/BlogDetails';
import CourseDetails from './components/CourseDetails';


function App() {
  const [view, setView] = useState("none");

  const showComponent = (component) => setView(component);

  return (
    <div style={{ padding: 20 }}>
      <h1>📘 BloggerApp - Conditional Rendering Demo</h1>
      <button onClick={() => showComponent("book")}>Show Book Details</button>
      <button onClick={() => showComponent("blog")}>Show Blog Details</button>
      <button onClick={() => showComponent("course")}>Show Course Details</button>
      <button onClick={() => showComponent("none")}>Clear</button>

      {/* Conditional Rendering with if-else using ternary */}
      {view === "book" ? <BookDetails /> :
       view === "blog" ? <BlogDetails /> :
       view === "course" ? <CourseDetails /> :
       <p>Please select a component to display.</p>}

      {/* Conditional Rendering using && */}
      {view === "book" && <p>You're viewing: Book</p>}
      {view === "blog" && <p>You're viewing: Blog</p>}
      {view === "course" && <p>You're viewing: Course</p>}
    </div>
  );
}

export default App;
