<script lang="ts">
	import { onMount, afterUpdate } from 'svelte';
	import { peaks } from './pcm';
	import WaveSurfer from 'wavesurfer.js';
	const audio = 'https://cdn.pixabay.com/audio/2022/04/25/audio_5d61b5204f.mp3';

	export let playing: boolean = false;

	let wavesurfer: any;
	let waveform: any;
	let canvas: any;
	let hover: any;

	$: togglePlay(playing);
	function togglePlay(playing: boolean) {
		if (!playing) wavesurfer?.pause();
		if (playing) wavesurfer?.play();
		console.log(playing);
	}

	onMount(async () => {
		const ctx = canvas.getContext('2d');

		// Define the waveform gradient
		const gradient = ctx!.createLinearGradient(0, 0, 0, canvas.height * 1.35);
		gradient.addColorStop(0, '#656666'); // Top color
		gradient.addColorStop((canvas.height * 0.7) / canvas.height, '#656666'); // Top color
		gradient.addColorStop((canvas.height * 0.7 + 1) / canvas.height, '#ffffff'); // White line
		gradient.addColorStop((canvas.height * 0.7 + 2) / canvas.height, '#ffffff'); // White line
		gradient.addColorStop((canvas.height * 0.7 + 3) / canvas.height, '#B1B1B1'); // Bottom color
		gradient.addColorStop(1, '#B1B1B1'); // Bottom color

		// Define the progress gradient
		const progressGradient = ctx!.createLinearGradient(0, 0, 0, canvas.height * 1.35);
		progressGradient.addColorStop(0, '#539CA8'); // Top color
		progressGradient.addColorStop((canvas.height * 0.7) / canvas.height, '#EB4926'); // Top color
		progressGradient.addColorStop((canvas.height * 0.7 + 1) / canvas.height, '#ffffff'); // White line
		progressGradient.addColorStop((canvas.height * 0.7 + 2) / canvas.height, '#ffffff'); // White line
		progressGradient.addColorStop((canvas.height * 0.7 + 3) / canvas.height, '#F6B094'); // Bottom color
		progressGradient.addColorStop(1, '#F6B094'); // Bottom color

		wavesurfer = WaveSurfer.create({
			container: waveform,
			waveColor: gradient,
			progressColor: progressGradient,
			cursorWidth: 2,
			cursorColor: '#539CA8',
			barWidth: 2,
			barGap: 8,
			barRadius: 10,
			height: 50,
			normalize: true
		});

		// Subscribe to the wavesurfer ready event to indicate that the waveform is loaded
		wavesurfer.on('ready', () => {
			waveform.style.opacity = '1';
		});

		wavesurfer.load(audio, peaks);
	});
</script>

<div
	id="waveform"
	class="w-full"
	bind:this={waveform}
	on:pointermove={(e) => (hover.style.width = `${e.offsetX}px`)}
>
	<div id="hover" bind:this={hover} />
	<canvas bind:this={canvas} class="h-0" />
</div>

<style>
	#waveform {
		cursor: pointer;
		position: relative;
		opacity: 0;
		transition: opacity 0.5s ease;
	}
	#hover {
		position: absolute;
		left: 0;
		top: 0;
		z-index: 10;
		pointer-events: none;
		height: 100%;
		width: 0;
		mix-blend-mode: overlay;
		background: rgba(255, 255, 255, 0.5);
		opacity: 0;
		transition: opacity 0.2s ease;
	}
	#waveform:hover #hover {
		opacity: 0.5;
	}
</style>
