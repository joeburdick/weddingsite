var drawingApp = (function () {
    "use strict";

    var canvasDiv,
        canvas,
        canvasWidth,
        canvasHeight,
        context,
        curColor = "#ffffff",
        curTool = "marker",
        curSize = "normal",
        clickX = [],
		clickY = [],
		clickColor = [],
		clickTool = [],
		clickSize = [],
		clickDrag = [],
        paint = false,

        clearCanvas = function () {

            context.clearRect(0, 0, canvasWidth, canvasHeight);
        },

        redraw = function () {

            var locX,
				locY,
				radius,
				i,
				selected;

            clearCanvas();

            // For each point drawn
            for (i = 0; i < clickX.length; i += 1) {

                // Set the drawing radius
                radius = 5

                // Set the drawing path
                context.beginPath();
                // If dragging then draw a line between the two points
                if (clickDrag[i] && i) {
                    context.moveTo(clickX[i - 1], clickY[i - 1]);
                } else {
                    // The x position is moved over one pixel so a circle even if not dragging
                    context.moveTo(clickX[i] - 1, clickY[i]);
                }
                context.lineTo(clickX[i], clickY[i]);

                // Set the drawing color
                if (clickTool[i] === "eraser") {
                    context.globalCompositeOperation = "destination-out"; // To erase instead of draw over with white
                } else {
                    context.globalCompositeOperation = "source-over";	// To erase instead of draw over with white
                }
                context.lineCap = "round";
                context.lineJoin = "round";
                context.lineWidth = radius;
                context.stroke();
            }
            context.closePath();
            context.restore();
        },

        addClick = function (x, y, dragging) {
        	clickX.push(x);
        	clickY.push(y);
        	clickTool.push(curTool);
        	clickColor.push(curColor);
        	clickSize.push(curSize);
        	clickDrag.push(dragging);
        },

        // Add mouse and touch event listeners to the canvas
		createUserEvents = function () {

		    var press = function (e) {
                var mouseX = (e.changedTouches ? e.changedTouches[0].pageX : e.pageX) - this.offsetLeft,
                mouseY = (e.changedTouches ? e.changedTouches[0].pageY : e.pageY) - this.offsetTop;

		        paint = true;
		        addClick(mouseX, mouseY, false);
		        redraw();
		    },

			drag = function (e) {

			    var mouseX = (e.changedTouches ? e.changedTouches[0].pageX : e.pageX) - this.offsetLeft,
					mouseY = (e.changedTouches ? e.changedTouches[0].pageY : e.pageY) - this.offsetTop;

			    if (paint) {
			        addClick(mouseX, mouseY, true);
			        redraw();
			    }
			    // Prevent the whole page from dragging if on mobile
			    e.preventDefault();
			},

			release = function () {
			    paint = false;
			    redraw();
			},

			cancel = function () {
			    paint = false;
			};

		    // Add mouse event listeners to canvas element
		    canvas.addEventListener("mousedown", press, false);
		    canvas.addEventListener("mousemove", drag, false);
		    canvas.addEventListener("mouseup", release);
		    canvas.addEventListener("mouseout", cancel, false);

		    // Add touch event listeners to canvas element
		    canvas.addEventListener("touchstart", press, false);
		    canvas.addEventListener("touchmove", drag, false);
		    canvas.addEventListener("touchend", release, false);
		    canvas.addEventListener("touchcancel", cancel, false);
		},

        init = function () {
            canvasDiv = document.getElementById('canvasDiv');
            canvas = document.createElement('canvas');
            canvasWidth = canvasDiv.offsetWidth;
            canvasHeight = canvasDiv.offsetHeight;
            canvas.setAttribute('width', canvasWidth);
            canvas.setAttribute('height', canvasHeight);

            if (typeof G_vmlCanvasManager !== "undefined") {
                canvas = G_vmlCanvasManager.initElement(canvas);
            }

            canvasDiv.appendChild(canvas);
            context = canvas.getContext("2d");

            createUserEvents();
        };

        return {
            init: init
        };
}());