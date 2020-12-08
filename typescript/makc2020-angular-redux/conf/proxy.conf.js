const PROXY_CONFIG = {

 '/.well-known/': {
    target: 'http://localhost:5000',
    secure: false    
  },
  '/connect/': {
    target: 'http://localhost:5000',
    secure: false
  },
  '/api/': {
    target: 'http://localhost:5000',
    secure: false,
    changeOrigin: true
  }
};

module.exports = PROXY_CONFIG;
