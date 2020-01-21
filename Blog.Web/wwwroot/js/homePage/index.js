/*

@Name：不落阁整站模板源码 
@Author：Absolutely 
@Site：http://www.lyblogs.cn

*/

layui.use(['jquery', 'flow'], function () {
    var $ = layui.jquery;
    var flow = layui.flow;

    // 信息流
    flow.load({
        elem: '.blog-main-left', // 指定列表容器
        isAuto: true, // 是否自动加载。默认true。如果设为false，点会在列表底部生成一个“加载更多”的button，则只能点击它才会加载下一页数据。
        end: '没有更多了', // 用于显示末页内容，可传入任意HTML字符。默认为：没有更多了
        mb: 200, // 与底部的临界距离，默认50。即当滚动条与底部产生该距离时，触发加载。注意：只有在isAuto为true时有效。额，等等。。mb=margin - bottom，可不是骂人的呀。
        done: function (page, next) { // 到达临界点(默认滚动触发)，触发下一页
            var pages; // 总页数
            var lis = [];

            if (false && page === 1) {
                next(lis.join(''), page < 999999);
                return;
            }

            $.ajax({
                type: 'post',
                url: '/GetMoreArticle',
                contentType: 'application/json',
                data: JSON.stringify({ "currentIndex": page, "pageSize": 10, "type": 1 }),
                //data: { "currentIndex": page, "pageSize": 10, "type": 1 },
                dataType: 'json',
                success: function (res) {
                    if (res.success) {
                        //lis.push(res.Data);
                        var temp = '<div class="article shadow animated zoomIn"><div class="article-left"><img src="/Images/Cover/201703051349045432.jpg" alt="一步步制作时光轴（二）（CSS篇）" /></div><div class="article-right"><div class="article-title"><a href="/Article/Detail/LY03051349129024">一步步制作时光轴（二）（CSS篇）</a></div><div class="article-abstract">由于本站点点滴滴栏目未开发，预备会加入时光轴和记事簿两大内容，在此将时光轴开发记录下来，与大家分享！</div ></div><div class="clear"></div><div class="article-footer"><span><i class="fa fa-clock-o"></i>&nbsp;&nbsp;2017-03-05 </span > <span class="article-author"><i class="fa fa-user"></i>&nbsp;&nbsp;Absolutely</span><span><i class="fa fa-tag"></i>&nbsp;&nbsp;<a href="/Article/Category/LY02212035218423">Web前端</a></span><span class="article-viewinfo"><i class="fa fa-eye"></i>&nbsp;1138</span><span class="article-viewinfo"><i class="fa fa-comment"></i>&nbsp;1</span></div></div><div class="article shadow animated zoomIn"><div class="article-left"><img src="/Images/Cover/201703050929515743.jpg" alt="一步步制作时光轴（一）（HTML篇）" /></div><div class="article-right"><div class="article-title"><a href="/Article/Detail/LY03050930010274">一步步制作时光轴（一）（HTML篇）</a></div><div class="article-abstract">由于本站点点滴滴栏目未开发，预备会加入时光轴和记事簿两大内容，在此将时光轴开发记录下来，与大家分享！</div ></div><div class="clear"></div><div class="article-footer"><span><i class="fa fa-clock-o"></i>&nbsp;&nbsp;2017-03-05 </span > <span class="article-author"><i class="fa fa-user"></i>&nbsp;&nbsp;Absolutely</span><span><i class="fa fa-tag"></i>&nbsp;&nbsp;<a href="/Article/Category/LY02212035218423">Web前端</a></span><span class="article-viewinfo"><i class="fa fa-eye"></i>&nbsp;1695</span><span class="article-viewinfo"><i class="fa fa-comment"></i>&nbsp;1</span></div></div><div class="article shadow animated zoomIn"><div class="article-left"><img src="/Images/Cover/201704151043566315.jpg" alt="C#基础知识回顾-扩展方法" /></div><div class="article-right"><div class="article-title"><a href="/Article/Detail/LY01161703441841">C#基础知识回顾-扩展方法</a></div><div class="article-abstract">扩展方法能够让你向现有类型“添加”方法，而无需创建新的派生类型、重新编译或以其他方式修改原始类型。扩展方法是一种特殊的静态方法，当可以像扩展类型上的实例方法一样进行调用。</div ></div><div class="clear"></div><div class="article-footer"><span><i class="fa fa-clock-o"></i>&nbsp;&nbsp;2017-03-04 </span > <span class="article-author"><i class="fa fa-user"></i>&nbsp;&nbsp;Absolutely</span><span><i class="fa fa-tag"></i>&nbsp;&nbsp;<a href="/Article/Category/LY02212035253489">C#基础</a></span><span class="article-viewinfo"><i class="fa fa-eye"></i>&nbsp;785</span><span class="article-viewinfo"><i class="fa fa-comment"></i>&nbsp;2</span></div></div><div class="article shadow animated zoomIn"><div class="article-left"><img src="/Images/Cover/201704151044301315.jpg" alt="ASP.NET MVC 防范跨站请求伪造（CSRF）" /></div><div class="article-right"><div class="article-title"><a href="/Article/Detail/LY01112209293355">ASP.NET MVC 防范跨站请求伪造（CSRF）</a></div><div class="article-abstract">上一篇博客简单介绍了下跨站请求伪造（以下简称CSRF），那么在ASP.NET MVC中如何防范CSRF？</div ></div><div class="clear"></div><div class="article-footer"><span><i class="fa fa-clock-o"></i>&nbsp;&nbsp;2017-01-11 </span > <span class="article-author"><i class="fa fa-user"></i>&nbsp;&nbsp;Absolutely</span><span><i class="fa fa-tag"></i>&nbsp;&nbsp;<a href="/Article/Category/LY02212035178403">ASP.NET MVC</a></span><span class="article-viewinfo"><i class="fa fa-eye"></i>&nbsp;793</span><span class="article-viewinfo"><i class="fa fa-comment"></i>&nbsp;2</span></div></div><div class="article shadow animated zoomIn"><div class="article-left"><img src="/Images/Cover/201704151044133971.jpg" alt="Web安全之跨站请求伪造CSRF" /></div><div class="article-right"><div class="article-title"><a href="/Article/Detail/LY01112008113667">Web安全之跨站请求伪造CSRF</a></div><div class="article-abstract"> 跨站请求伪造：（英语：Cross-site request forgery）缩写为CSRF，是一种挟持用户在当前已登录的Web应用程序上执行非本意操作的攻击方法。</div ></div><div class="clear"></div><div class="article-footer"><span><i class="fa fa-clock-o"></i>&nbsp;&nbsp;2017-01-11 </span > <span class="article-author"><i class="fa fa-user"></i>&nbsp;&nbsp;Absolutely</span><span><i class="fa fa-tag"></i>&nbsp;&nbsp;<a href="/Article/Category/LY02212035178403">ASP.NET MVC</a></span><span class="article-viewinfo"><i class="fa fa-eye"></i>&nbsp;788</span><span class="article-viewinfo"><i class="fa fa-comment"></i>&nbsp;5</span></div></div><div class="article shadow animated zoomIn"><div class="article-left"><img src="/Images/Cover/201704151046237573.jpg" alt="浅谈.NET Framework基元类型" /></div><div class="article-right"><div class="article-title"><a href="/Article/Detail/LY01112018564605">浅谈.NET Framework基元类型</a></div><div class="article-abstract">初学者可能很少听说过这个名词，但是平时用得最多的肯定是基元类型。</div ></div><div class="clear"></div><div class="article-footer"><span><i class="fa fa-clock-o"></i>&nbsp;&nbsp;2017-03-04 </span > <span class="article-author"><i class="fa fa-user"></i>&nbsp;&nbsp;Absolutely</span><span><i class="fa fa-tag"></i>&nbsp;&nbsp;<a href="/Article/Category/LY02212035253489">C#基础</a></span><span class="article-viewinfo"><i class="fa fa-eye"></i>&nbsp;675</span><span class="article-viewinfo"><i class="fa fa-comment"></i>&nbsp;1</span></div></div><div class="article shadow animated zoomIn"><div class="article-left"><img src="/Images/Cover/201704151045171784.jpg" alt="EF CodeFirst数据迁移常用指令" /></div><div class="article-right"><div class="article-title"><a href="/Article/Detail/LY02141605159879">EF CodeFirst数据迁移常用指令</a></div><div class="article-abstract">EF CodeFirst 数据迁移nuget控制台常用指令</div ></div><div class="clear"></div><div class="article-footer"><span><i class="fa fa-clock-o"></i>&nbsp;&nbsp;2017-03-04 </span > <span class="article-author"><i class="fa fa-user"></i>&nbsp;&nbsp;Absolutely</span><span><i class="fa fa-tag"></i>&nbsp;&nbsp;<a href="/Article/Category/LY02212035203846">Entity Framework</a></span><span class="article-viewinfo"><i class="fa fa-eye"></i>&nbsp;740</span><span class="article-viewinfo"><i class="fa fa-comment"></i>&nbsp;1</span></div></div><div class="article shadow animated zoomIn"><div class="article-left"><img src="/Images/Cover/201704151045354752.jpg" alt="常用正则表达式" /></div><div class="article-right"><div class="article-title"><a href="/Article/Detail/LY02081705056778">常用正则表达式</a></div><div class="article-abstract">常用正则表达式总结</div ></div><div class="clear"></div><div class="article-footer"><span><i class="fa fa-clock-o"></i>&nbsp;&nbsp;2017-02-08 </span > <span class="article-author"><i class="fa fa-user"></i>&nbsp;&nbsp;Absolutely</span><span><i class="fa fa-tag"></i>&nbsp;&nbsp;<a href="/Article/Category/LY02212035253489">C#基础</a></span><span class="article-viewinfo"><i class="fa fa-eye"></i>&nbsp;971</span><span class="article-viewinfo"><i class="fa fa-comment"></i>&nbsp;1</span></div></div>';
                        lis.push(temp);
                        pages = 10;//res.SubCode;
                        next(lis.join(''), page < pages);
                    } else {
                        layer.msg('获取数据失败', { icon: 2 });
                    }
                },
                error: function (e) {
                    layer.msg(e.responseText);
                },
                complete: function (e) {
                    console.log(e.responseText);
                }
            });
        }
    });

    $(function () {
        //画canvas
        DrawCanvas();
        //播放公告
        playAnnouncement(3000);
    });


    // 画canvas
    function DrawCanvas() {
        var $ = layui.jquery;
        var canvas = document.getElementById('canvas-banner');
        canvas.width = window.document.body.clientWidth;    //需要重新设置canvas宽度，因为dom加载完毕后有可能没有滚动条
        var ctx = canvas.getContext('2d');

        ctx.strokeStyle = (new Color(150)).style;

        var dotCount = 20; //圆点数量
        var dotRadius = 70; //产生连线的范围
        var dotDistance = 70;   //产生连线的最小距离
        var screenWidth = screen.width;
        if (screenWidth >= 768 && screenWidth < 992) {
            dotCount = 130;
            dotRadius = 100;
            dotDistance = 60;
        } else if (screenWidth >= 992 && screenWidth < 1200) {
            dotCount = 140;
            dotRadius = 140;
            dotDistance = 70;
        } else if (screenWidth >= 1200 && screenWidth < 1700) {
            dotCount = 140;
            dotRadius = 150;
            dotDistance = 80;
        } else if (screenWidth >= 1700) {
            dotCount = 200;
            dotRadius = 150;
            dotDistance = 80;
        }
        //默认鼠标位置 canvas 中间
        var mousePosition = {
            x: 50 * canvas.width / 100,
            y: 50 * canvas.height / 100
        };
        //小圆点
        var dots = {
            count: dotCount,
            distance: dotDistance,
            d_radius: dotRadius,
            array: []
        };

        function colorValue(min) {
            return Math.floor(Math.random() * 255 + min);
        }

        function createColorStyle(r, g, b) {
            return 'rgba(' + r + ',' + g + ',' + b + ', 0.8)';
        }

        function mixComponents(comp1, weight1, comp2, weight2) {
            return (comp1 * weight1 + comp2 * weight2) / (weight1 + weight2);
        }

        function averageColorStyles(dot1, dot2) {
            var color1 = dot1.color,
                color2 = dot2.color;

            var r = mixComponents(color1.r, dot1.radius, color2.r, dot2.radius),
                g = mixComponents(color1.g, dot1.radius, color2.g, dot2.radius),
                b = mixComponents(color1.b, dot1.radius, color2.b, dot2.radius);
            return createColorStyle(Math.floor(r), Math.floor(g), Math.floor(b));
        }

        function Color(min) {
            min = min || 0;
            this.r = colorValue(min);
            this.g = colorValue(min);
            this.b = colorValue(min);
            this.style = createColorStyle(this.r, this.g, this.b);
        }

        function Dot() {
            this.x = Math.random() * canvas.width;
            this.y = Math.random() * canvas.height;

            this.vx = -.5 + Math.random();
            this.vy = -.5 + Math.random();

            this.radius = Math.random() * 2;

            this.color = new Color();
        }

        Dot.prototype = {
            draw: function () {
                ctx.beginPath();
                ctx.fillStyle = "#fff";
                ctx.arc(this.x, this.y, this.radius, 0, Math.PI * 2, false);
                ctx.fill();
            }
        };

        function createDots() {
            for (i = 0; i < dots.count; i++) {
                dots.array.push(new Dot());
            }
        }

        function moveDots() {
            for (i = 0; i < dots.count; i++) {

                var dot = dots.array[i];

                if (dot.y < 0 || dot.y > canvas.height) {
                    dot.vx = dot.vx;
                    dot.vy = -dot.vy;
                }
                else if (dot.x < 0 || dot.x > canvas.width) {
                    dot.vx = -dot.vx;
                    dot.vy = dot.vy;
                }
                dot.x += dot.vx;
                dot.y += dot.vy;
            }
        }

        function connectDots1() {
            var pointx = mousePosition.x;
            for (i = 0; i < dots.count; i++) {
                for (j = 0; j < dots.count; j++) {
                    i_dot = dots.array[i];
                    j_dot = dots.array[j];

                    if ((i_dot.x - j_dot.x) < dots.distance && (i_dot.y - j_dot.y) < dots.distance && (i_dot.x - j_dot.x) > -dots.distance && (i_dot.y - j_dot.y) > -dots.distance) {
                        if ((i_dot.x - pointx) < dots.d_radius && (i_dot.y - mousePosition.y) < dots.d_radius && (i_dot.x - pointx) > -dots.d_radius && (i_dot.y - mousePosition.y) > -dots.d_radius) {
                            ctx.beginPath();
                            ctx.strokeStyle = averageColorStyles(i_dot, j_dot);
                            ctx.moveTo(i_dot.x, i_dot.y);
                            ctx.lineTo(j_dot.x, j_dot.y);
                            ctx.stroke();
                            ctx.closePath();
                        }
                    }
                }
            }
        }

        function drawDots() {
            for (i = 0; i < dots.count; i++) {
                var dot = dots.array[i];
                dot.draw();
            }
        }

        function animateDots() {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            moveDots();
            connectDots1()
            drawDots();

            requestAnimationFrame(animateDots);
        }
        //鼠标在canvas上移动
        $('canvas').on('mousemove', function (e) {
            mousePosition.x = e.pageX;
            mousePosition.y = e.pageY;
        });

        //鼠标移出canvas
        $('canvas').on('mouseleave', function (e) {
            mousePosition.x = canvas.width / 2;
            mousePosition.y = canvas.height / 2;
        });

        createDots();

        requestAnimationFrame(animateDots);
    }
    // 播放公告
    function playAnnouncement(interval) {
        var index = 0;
        var $announcement = $('.home-tips-container>span');
        //自动轮换
        setInterval(function () {
            index++;    //下标更新
            if (index >= $announcement.length) {
                index = 0;
            }
            $announcement.eq(index).stop(true, true).fadeIn().siblings('span').fadeOut();  //下标对应的图片显示，同辈元素隐藏
        }, interval);
    }

    //监听窗口大小改变
    window.addEventListener("resize", resizeCanvas, false);

    //窗口大小改变时改变canvas宽度
    function resizeCanvas() {
        var canvas = document.getElementById('canvas-banner');
        canvas.width = window.document.body.clientWidth;
        canvas.height = window.innerHeight * 1 / 3;
    }
    
});

