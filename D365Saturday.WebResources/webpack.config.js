var webpack = require('webpack');
var path = require('path');

var BUILD_DIR = path.resolve(__dirname, 'src/client');
var APP_DIR = path.resolve(__dirname, 'src/app');

var configs = [
    {
        entry: APP_DIR + '/index.jsx',
        output: {
            path: BUILD_DIR + '/public/js',
            filename: 'bundle.js'
        },
        module: {
            loaders: [
                {
                    test: /\.jsx?/,
                    include: APP_DIR,
                    loader: 'babel-loader'
                }
            ]
        },
        resolve: {
            extensions: ['.js', '.jsx']
        }
    }
];

module.exports = configs;



