import React, { Component } from 'react';
import Post from './Post';

class Posts extends Component {
    constructor(props) {
        super(props);
        this.state = {
            posts: []
        };
    }

    loadPosts() {
        fetch('https://jsonplaceholder.typicode.com/posts')
            .then(response => response.json())
            .then(data => {
                const posts = data.map(item => 
                    new Post(item.id, item.title, item.body, item.userId)
                );
                this.setState({ posts: posts });
            })
            .catch(error => {
                console.error('Error fetching posts:', error);
                alert('Failed to load posts. Please try again later.');
            });
    }

    componentDidMount() {
        console.log('Component mounted - loading posts...');
        this.loadPosts();
    }

    componentDidCatch(error, errorInfo) {
        console.error('Component caught an error:', error, errorInfo);
        alert(`An error occurred: ${error.message}`);
    }

    render() {
        const { posts } = this.state;

        return (
            <div style={{ padding: '20px', maxWidth: '800px', margin: '0 auto' }}>
                <h1 style={{ textAlign: 'center', color: '#333', marginBottom: '30px' }}>
                    Blog Posts
                </h1>
                
                {posts.length === 0 ? (
                    <p style={{ textAlign: 'center', fontSize: '18px', color: '#666' }}>
                        Loading posts...
                    </p>
                ) : (
                    <div>
                        {posts.map(post => (
                            <div key={post.id} style={{
                                border: '1px solid #ddd',
                                borderRadius: '8px',
                                padding: '20px',
                                marginBottom: '20px',
                                backgroundColor: '#f9f9f9',
                                boxShadow: '0 2px 4px rgba(0,0,0,0.1)'
                            }}>
                                <h2 style={{
                                    color: '#2c3e50',
                                    marginBottom: '10px',
                                    fontSize: '1.5em',
                                    textTransform: 'capitalize'
                                }}>
                                    {post.title}
                                </h2>
                                <p style={{
                                    color: '#555',
                                    lineHeight: '1.6',
                                    fontSize: '16px',
                                    marginBottom: '10px'
                                }}>
                                    {post.body}
                                </p>
                                <small style={{
                                    color: '#888',
                                    fontStyle: 'italic'
                                }}>
                                    Post ID: {post.id} | User ID: {post.userId}
                                </small>
                            </div>
                        ))}
                    </div>
                )}
            </div>
        );
    }
}

export default Posts;