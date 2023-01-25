const colors = require('tailwindcss/colors')

module.exports = {
    content: ["./src/**/*.{html,js}"],
    darkMode: 'class',
    theme: {
        spacing: {
            'enough': '6rem'
        }
        extend: {
            colors: {
                ranD: '#3f3cbb',
                stone: colors.warmGray,
                sky: colors.lightBlue,
                neutral: colors.trueGray,
                gray: colors.coolGray,
                slate: colors.blueGray,
                amber: colors.amber,
                emerald: colors.emerald,
            }        },
    },
   
}